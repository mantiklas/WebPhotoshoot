import { TestBed } from '@angular/core/testing';

import { PhotobootService } from './photoboot.service';

describe('PhotobootService', () => {
  beforeEach(() => TestBed.configureTestingModule({}));

  it('should be created', () => {
    const service: PhotobootService = TestBed.get(PhotobootService);
    expect(service).toBeTruthy();
  });
});
