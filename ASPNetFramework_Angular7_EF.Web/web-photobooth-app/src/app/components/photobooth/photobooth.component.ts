import { Component, OnInit } from '@angular/core';
import { WebcamInitError, WebcamImage, WebcamUtil } from 'ngx-webcam';
import { Subject, Observable, Observer } from 'rxjs';
import { fabric } from 'fabric';
import { PhotobootService } from '../../photoboot.service';
import { EmailDto } from 'src/app/Model/EmailDto';
import { Guid } from "guid-typescript";
import { NgbModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { EmailModalComponent } from 'src/app/shared/modals/email-modal/email-modal.component';

@Component({
  selector: 'app-photobooth',
  templateUrl: './photobooth.component.html',
  styleUrls: ['./photobooth.component.scss']
})
export class PhotoboothComponent implements OnInit {

  constructor(config: NgbModalConfig, private photobootservice: PhotobootService, private modalService: NgbModal) { }

  public showWebcam = true;
  public allowCameraSwitch = true;
  public multipleWebcamsAvailable = false;
  public deviceId: string;
  public facingMode: string = 'environment';
  public errors: WebcamInitError[] = [];
  public canvas: any;
  public emailDto: EmailDto;
  public fileName: string = null;
  public email: string = "";
  public showSend = false;
  // latest snapshot
  public webcamImage: WebcamImage = null;

  // webcam snapshot trigger
  private trigger: Subject<void> = new Subject<void>();
  // switch to next / previous / specific webcam; true/false: forward/backwards, string: deviceId
  private nextWebcam: Subject<boolean | string> = new Subject<boolean | string>();

  public ngOnInit(): void {

    this.canvas = new fabric.Canvas('myCanvas');
    //console.log(this.canvas);
    WebcamUtil.getAvailableVideoInputs()
      .then((mediaDevices: MediaDeviceInfo[]) => {
        this.multipleWebcamsAvailable = mediaDevices && mediaDevices.length > 1;
      });
  }

  download() {
    let img = new Image();
    img.crossOrigin = 'Anonymous';
    img.src = this.webcamImage.imageAsDataUrl;
    this.getBase64Image(img);
    this.showSend = true;
  }

  getBase64Image(img: HTMLImageElement) {
    // We create a HTML canvas object that will create a 2d image
    this.canvas.width = img.width;
    this.canvas.height = img.height;
    //var ctx = this.canvas.getContext("2d");
    // This will draw image    
    //ctx.drawImage(img, 0, 0);
    // Convert the drawn image to Data URL

    var dataURL = this.canvas.toDataURL({
      format: 'png',
      quality: 0.8
    });
    this.generateLinkForDownload(dataURL.replace(/^data:image\/(png|jpg);base64,/, ""));
  }

  generateLinkForDownload(base64content: any) {
    const blobData = this.convertBase64ToBlobData(base64content);

    this.fileName = Guid.create().toString() + ".png";
    console.log("fileName >> ", this.fileName);
    //const blobData = this.convertBase64ToBlobData(base64content);
    //let filename = "sample.png";

    if (window.navigator && window.navigator.msSaveOrOpenBlob) { //IE
      window.navigator.msSaveOrOpenBlob(blobData, this.fileName);
    } else { // chrome
      const blob = new Blob([blobData], { type: 'image/png' });
      const url = window.URL.createObjectURL(blob);
      window.open(url);
      const link = document.createElement('a');
      link.href = url;
      link.download = this.fileName;
      link.click();
    }
  }

  convertBase64ToBlobData(base64Data: string, contentType: string = 'image/png', sliceSize = 512) {
    const byteCharacters = window.atob(base64Data);
    const byteArrays = [];

    for (let offset = 0; offset < byteCharacters.length; offset += sliceSize) {
      const slice = byteCharacters.slice(offset, offset + sliceSize);

      const byteNumbers = new Array(slice.length);
      for (let i = 0; i < slice.length; i++) {
        byteNumbers[i] = slice.charCodeAt(i);
      }

      const byteArray = new Uint8Array(byteNumbers);

      byteArrays.push(byteArray);
    }

    const blob = new Blob(byteArrays, { type: contentType });
    return blob;
  }

  addSticker() {
    var canvas2 = this.canvas;
    fabric.Image.fromURL('.../../assets/Image/smiley.png', function (
      oImg
    ) {
      oImg.scale(0.1);
      canvas2.add(oImg);
    });
  }

  public triggerSnapshot(): void {
    this.trigger.next();
    console.log("webcamImage >> ", this.webcamImage);
    console.log("canvas >> ", this.canvas);
    this.canvas.backgroundColor = 'yellow';
    this.canvas.setBackgroundImage(this.webcamImage.imageAsDataUrl, this.canvas.renderAll.bind(this.canvas));
  }

  public toggleWebcam(): void {
    this.showWebcam = !this.showWebcam;

  }

  public handleInitError(error: WebcamInitError): void {
    if (error.mediaStreamError && error.mediaStreamError.name === "NotAllowedError") {
      console.warn("Camera access was not allowed by user!");
    }
    this.errors.push(error);
  }

  public showNextWebcam(directionOrDeviceId: boolean | string): void {
    // true => move forward through devices
    // false => move backwards through devices
    // string => move to device with given deviceId
    this.nextWebcam.next(directionOrDeviceId);
  }

  public handleImage(webcamImage: WebcamImage): void {
    console.log('received webcam image', webcamImage);
    this.webcamImage = webcamImage;
  }

  public cameraWasSwitched(deviceId: string): void {
    console.log('active device: ' + deviceId);
    this.deviceId = deviceId;
  }

  public get triggerObservable(): Observable<void> {
    return this.trigger.asObservable();
  }

  public get nextWebcamObservable(): Observable<boolean | string> {
    return this.nextWebcam.asObservable();
  }

  public get videoOptions(): MediaTrackConstraints {
    const result: MediaTrackConstraints = {};
    if (this.facingMode && this.facingMode !== "") {
      result.facingMode = { ideal: this.facingMode };
    }

    return result;
  }

  emailEntry() {
    const modalRef = this.modalService.open(EmailModalComponent, { centered: true });
    modalRef.componentInstance.yesLabel = 'Yes';
    modalRef.componentInstance.noLabel = 'No';

    modalRef.result.then((result) => { //
      this.send(result);
    }, (reason) => { //CLEAN ALL FIELDS
      //this.isLoading = false;
    });
  }

  send(emailAddress) {
    console.log("email >> ", emailAddress);
    console.log("fileName >> ", this.fileName);
    this.emailDto = new EmailDto();
    this.emailDto.CCEmails = [];
    this.emailDto.ToEmails = [];
    this.emailDto.PathAttachments = [];
    this.emailDto.CCEmails.push("anam@erni.ph");
    this.emailDto.ToEmails.push(emailAddress);
    this.emailDto.PathAttachments.push("C:\\Users\\dela\\Downloads\\" + this.fileName);
    this.emailDto.Subject = "Web Photoshoot";
    this.emailDto.Message = "Hi, please see attachment for your picture.";
    this.photobootservice.send(this.emailDto).subscribe(data => {
      console.log(data);
    }), error => {
      alert("Internet access required");
    };
  }
}
