/* tslint:disable */
/* eslint-disable */
import { Injectable } from '@angular/core';
import { HttpClient, HttpResponse, HttpContext } from '@angular/common/http';
import { BaseService } from '../base-service';
import { ApiConfiguration } from '../api-configuration';
import { StrictHttpResponse } from '../strict-http-response';
import { RequestBuilder } from '../request-builder';
import { Observable } from 'rxjs';
import { map, filter } from 'rxjs/operators';

import { Usuarios } from '../models/usuarios';

@Injectable({
  providedIn: 'root',
})
export class UsuariosService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiUsuariosGet
   */
  static readonly ApiUsuariosGetPath = '/api/usuarios';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUsuariosGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUsuariosGet$Plain$Response(params?: {
    context?: HttpContext
  }
): Observable<StrictHttpResponse<Array<Usuarios>>> {

    const rb = new RequestBuilder(this.rootUrl, UsuariosService.ApiUsuariosGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<Usuarios>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUsuariosGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUsuariosGet$Plain(params?: {
    context?: HttpContext
  }
): Observable<Array<Usuarios>> {

    return this.apiUsuariosGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<Usuarios>>) => r.body as Array<Usuarios>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUsuariosGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUsuariosGet$Json$Response(params?: {
    context?: HttpContext
  }
): Observable<StrictHttpResponse<Array<Usuarios>>> {

    const rb = new RequestBuilder(this.rootUrl, UsuariosService.ApiUsuariosGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<Usuarios>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUsuariosGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUsuariosGet$Json(params?: {
    context?: HttpContext
  }
): Observable<Array<Usuarios>> {

    return this.apiUsuariosGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<Usuarios>>) => r.body as Array<Usuarios>)
    );
  }

  /**
   * Path part for operation apiUsuariosPost
   */
  static readonly ApiUsuariosPostPath = '/api/usuarios';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUsuariosPost()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsuariosPost$Response(params?: {
    context?: HttpContext
    body?: Usuarios
  }
): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, UsuariosService.ApiUsuariosPostPath, 'post');
    if (params) {
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUsuariosPost$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsuariosPost(params?: {
    context?: HttpContext
    body?: Usuarios
  }
): Observable<void> {

    return this.apiUsuariosPost$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiUsuariosIdPut
   */
  static readonly ApiUsuariosIdPutPath = '/api/usuarios/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUsuariosIdPut()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsuariosIdPut$Response(params: {
    id: number;
    context?: HttpContext
    body?: Usuarios
  }
): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, UsuariosService.ApiUsuariosIdPutPath, 'put');
    if (params) {
      rb.path('id', params.id, {});
      rb.body(params.body, 'application/*+json');
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUsuariosIdPut$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiUsuariosIdPut(params: {
    id: number;
    context?: HttpContext
    body?: Usuarios
  }
): Observable<void> {

    return this.apiUsuariosIdPut$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiUsuariosIdDelete
   */
  static readonly ApiUsuariosIdDeletePath = '/api/usuarios/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiUsuariosIdDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUsuariosIdDelete$Response(params: {
    id: number;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, UsuariosService.ApiUsuariosIdDeletePath, 'delete');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: '*/*',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return (r as HttpResponse<any>).clone({ body: undefined }) as StrictHttpResponse<void>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiUsuariosIdDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiUsuariosIdDelete(params: {
    id: number;
    context?: HttpContext
  }
): Observable<void> {

    return this.apiUsuariosIdDelete$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

}
