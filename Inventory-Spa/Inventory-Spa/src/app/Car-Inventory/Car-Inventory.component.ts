import { InventoryServiceService } from './../../InventoryService.service';
import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormBuilder, FormControl, FormGroup, FormsModule } from '@angular/forms';
import { Inventory } from '../../InventoryModel';

@Component({
  // tslint:disable-next-line: component-selector
  selector: 'app-Car-Inventory',
  templateUrl: './Car-Inventory.component.html',
  styleUrls: ['./Car-Inventory.component.scss']
})
export class CarInventoryComponent implements OnInit {

  inventoryForm: FormGroup;
  CarName: FormControl;
  Model: FormControl;
  StockQty: FormControl;
  inventoryList: Inventory [];
  resmessage : string;
  inventory: Inventory;

  constructor(private builder: FormBuilder, private inventoryService: InventoryServiceService) { }

  // tslint:disable-next-line: typedef
  ngOnInit() {
    this.resmessage = '';
    this.getInventory();
  }

  // tslint:disable-next-line: typedef
  FormGroup() {
    this.CarName = new FormControl();
    this.Model = new FormControl();
    this.StockQty = new FormControl('');
    this.inventoryForm = this.builder.group({
      CarName: this.CarName,
      Model: this.Model,
      StockQty: this.StockQty
    });
}

// tslint:disable-next-line: typedef
getInventory() {
  this.inventoryService.getCarInventoryList().subscribe(
    cars => this.inventoryList = cars);
}

saveInventory(inventory: Inventory) { 
  this.inventoryService.AddNewInventory(inventory).subscribe(response => {
      this.inventory = response;
      this.getInventory();
  });
} 
}
