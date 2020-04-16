import { TestBed } from '@angular/core/testing';

import { AuthCustomValidatorsService } from './auth-custom-validators.service';

describe('AuthCustomValidatorsService', () => {
  let service: AuthCustomValidatorsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AuthCustomValidatorsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
