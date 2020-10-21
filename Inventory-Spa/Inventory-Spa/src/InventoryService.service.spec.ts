/* tslint:disable:no-unused-variable */

import { TestBed, async, inject } from '@angular/core/testing';
import { InventoryServiceService } from './InventoryService.service';

describe('Service: InventoryService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [InventoryServiceService]
    });
  });

  it('should ...', inject([InventoryServiceService], (service: InventoryServiceService) => {
    expect(service).toBeTruthy();
  }));
});
