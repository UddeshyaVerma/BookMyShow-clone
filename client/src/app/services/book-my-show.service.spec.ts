import { TestBed } from '@angular/core/testing';

import { BookMyShowService } from './book-my-show.service';

describe('BookMyShowService', () => {
  let service: BookMyShowService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(BookMyShowService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
