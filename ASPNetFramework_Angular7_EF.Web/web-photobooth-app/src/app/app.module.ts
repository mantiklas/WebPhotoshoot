import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PhotoboothComponent } from './components/photobooth/photobooth.component';
import {WebcamModule} from 'ngx-webcam';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { ApiService } from './services/ApiServices';
import { PhotobootService } from './photoboot.service';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { EmailModalComponent } from './shared/modals/email-modal/email-modal.component';

@NgModule({
  declarations: [
    AppComponent,
    PhotoboothComponent,
    EmailModalComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    WebcamModule,
    HttpClientModule,
    NgbModule
  ],
  entryComponents: [
    EmailModalComponent
  ],
  providers: [ApiService, PhotobootService,HttpClient],
  bootstrap: [AppComponent]
})
export class AppModule { }
