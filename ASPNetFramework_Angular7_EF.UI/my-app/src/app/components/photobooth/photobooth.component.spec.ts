import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PhotoboothComponent } from './photobooth.component';

describe('PhotoboothComponent', () => {
  let component: PhotoboothComponent;
  let fixture: ComponentFixture<PhotoboothComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PhotoboothComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PhotoboothComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
