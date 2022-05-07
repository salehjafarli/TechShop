import { HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Product, ProductCreate, ProductUpdate } from 'src/app/core/Models/Product';
import { ResponseModel } from '../Models/ResponseModel';
import {ApiService } from './api.service'


@Injectable()
export class ProductService {
    private slug : String  = "product"

    constructor(public apiService : ApiService) {}

    getAll(): Observable<ResponseModel<Array<Product>>> {
        var obobj = this.apiService.get(`${this.slug}`);
        return obobj;
    }
    getById( id : number): Observable<ResponseModel<Product>> {
        var obobj = this.apiService.get(`${this.slug}/${id}`);
        return obobj;
    }
    create(data : ProductCreate): Observable<ResponseModel<boolean>> {
        var obobj = this.apiService.post(`${this.slug}`, data);
        return obobj;
    }
    update(data : ProductUpdate): Observable<ResponseModel<boolean>>  {
        var obobj = this.apiService.put(`${this.slug}`, data);
        return obobj;
    }
    delete(id : number): Observable<ResponseModel<boolean>> {
        var params = new HttpParams();
        params = params.set("id",id);
        var obobj = this.apiService.delete(`${this.slug}`, params);
        return obobj;
    }

}