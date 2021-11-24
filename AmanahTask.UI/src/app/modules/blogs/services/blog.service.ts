import { Injectable } from '@angular/core';
import { HttpParams } from '@angular/common/http';
import { WebApiService } from '../../shared/services/web-api.service';


@Injectable({
  providedIn: 'root'
})
export class BlogService {
  private controller: string = 'Blog';
  constructor(private webApi: WebApiService) { }
  Search(filter: IFilterBlog) {
    return this.webApi.get(`${this.controller}/Get`,
      Object.getOwnPropertyNames(filter).reduce((p, key) => p.set(key, filter[key]), new HttpParams()));
  }
  GetByID(id: number) {
    return this.webApi.get(`${this.controller}/GetById/${id}`);
  }
  GetList() {

    return this.webApi.get(`${this.controller}/GetList`);
  }
  Post(body) {
    return this.webApi.post(`${this.controller}/Post`, body);
  }
  Put(body) {
    return this.webApi.put(`${this.controller}/Put`, body);
  }
  Delete(id: number) {
    return this.webApi.delete(`${this.controller}/Delete/${id}`);
  }
}
export interface IFilterBlog {
  pageSize?: any,
  name?: string,
  orderBy?: string,
  isAscending?: boolean,
  pageIndex?: number,

};
