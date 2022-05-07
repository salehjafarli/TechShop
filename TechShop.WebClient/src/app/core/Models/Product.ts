import { NumberValueAccessor } from "@angular/forms";
import { Category } from "./Category";

export class Product
{
    public no! : number;
    public id! : number;
    public name! : string;
    public value! : number;
    public category! : Category
}


export class ProductCreate {
    public name! : string;
    public value! : number;
    public categoryid! : number;

}

export class ProductUpdate extends ProductCreate{
    public id! : number;
}