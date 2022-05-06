import { IModel } from "./IModel";

export class Product implements IModel
{
    public id! : number;
    public name! : string;
    public value! : number;
}