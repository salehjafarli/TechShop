import { HttpClient, HttpParams }from '@angular/common/http';
import { Injectable } from '@angular/core';
import { apiUrl } from '../consts';
import { ResponseModel } from '../Models/ResponseModel';


@Injectable()
export class ApiService
{
    constructor(public httpclient : HttpClient) {}
    public get(slug : String, params : HttpParams = new HttpParams()){
        return this.httpclient.get<ResponseModel<any>>(`${apiUrl}/${slug}`,{params});
    }
    public post(slug : String, body : Object = {}){
        return this.httpclient.post<ResponseModel<any>>(`${apiUrl}/${slug}`, body);
    }
    public put(slug : String, body : Object = {}){
        return this.httpclient.put<ResponseModel<any>>(`${apiUrl}/${slug}`, body);
    }
    public delete(slug : String, params : HttpParams = new HttpParams()){
        return this.httpclient.delete<ResponseModel<any>>(`${apiUrl}/${slug}`,{params});
    }
}