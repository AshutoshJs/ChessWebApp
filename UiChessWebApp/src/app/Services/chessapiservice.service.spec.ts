import { TestBed } from '@angular/core/testing';

import { ChessapiserviceService } from './chessapiservice.service';

describe('ChessapiserviceService', () => {
  let service: ChessapiserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ChessapiserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
