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

import { Personas } from '../models/personas';

@Injectable({
  providedIn: 'root',
})
export class PersonasService extends BaseService {
  constructor(
    config: ApiConfiguration,
    http: HttpClient
  ) {
    super(config, http);
  }

  /**
   * Path part for operation apiPersonasGet
   */
  static readonly ApiPersonasGetPath = '/api/personas';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPersonasGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPersonasGet$Plain$Response(params?: {
    context?: HttpContext
  }
): Observable<StrictHttpResponse<Array<Personas>>> {

    const rb = new RequestBuilder(this.rootUrl, PersonasService.ApiPersonasGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<Personas>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiPersonasGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPersonasGet$Plain(params?: {
    context?: HttpContext
  }
): Observable<Array<Personas>> {

    return this.apiPersonasGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<Array<Personas>>) => r.body as Array<Personas>)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPersonasGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPersonasGet$Json$Response(params?: {
    context?: HttpContext
  }
): Observable<StrictHttpResponse<Array<Personas>>> {

    const rb = new RequestBuilder(this.rootUrl, PersonasService.ApiPersonasGetPath, 'get');
    if (params) {
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<Array<Personas>>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiPersonasGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPersonasGet$Json(params?: {
    context?: HttpContext
  }
): Observable<Array<Personas>> {

    return this.apiPersonasGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<Array<Personas>>) => r.body as Array<Personas>)
    );
  }

  /**
   * Path part for operation apiPersonasPost
   */
  static readonly ApiPersonasPostPath = '/api/personas';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPersonasPost()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiPersonasPost$Response(params?: {
    context?: HttpContext
    body?: Personas
  }
): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, PersonasService.ApiPersonasPostPath, 'post');
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
   * To access the full response (for headers, for example), `apiPersonasPost$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiPersonasPost(params?: {
    context?: HttpContext
    body?: Personas
  }
): Observable<void> {

    return this.apiPersonasPost$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiPersonasIdGet
   */
  static readonly ApiPersonasIdGetPath = '/api/personas/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPersonasIdGet$Plain()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPersonasIdGet$Plain$Response(params: {
    id: number;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<string>> {

    const rb = new RequestBuilder(this.rootUrl, PersonasService.ApiPersonasIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'text',
      accept: 'text/plain',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<string>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiPersonasIdGet$Plain$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPersonasIdGet$Plain(params: {
    id: number;
    context?: HttpContext
  }
): Observable<string> {

    return this.apiPersonasIdGet$Plain$Response(params).pipe(
      map((r: StrictHttpResponse<string>) => r.body as string)
    );
  }

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPersonasIdGet$Json()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPersonasIdGet$Json$Response(params: {
    id: number;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<string>> {

    const rb = new RequestBuilder(this.rootUrl, PersonasService.ApiPersonasIdGetPath, 'get');
    if (params) {
      rb.path('id', params.id, {});
    }

    return this.http.request(rb.build({
      responseType: 'json',
      accept: 'text/json',
      context: params?.context
    })).pipe(
      filter((r: any) => r instanceof HttpResponse),
      map((r: HttpResponse<any>) => {
        return r as StrictHttpResponse<string>;
      })
    );
  }

  /**
   * This method provides access to only to the response body.
   * To access the full response (for headers, for example), `apiPersonasIdGet$Json$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPersonasIdGet$Json(params: {
    id: number;
    context?: HttpContext
  }
): Observable<string> {

    return this.apiPersonasIdGet$Json$Response(params).pipe(
      map((r: StrictHttpResponse<string>) => r.body as string)
    );
  }

  /**
   * Path part for operation apiPersonasIdPut
   */
  static readonly ApiPersonasIdPutPath = '/api/personas/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPersonasIdPut()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiPersonasIdPut$Response(params: {
    id: number;
    context?: HttpContext
    body?: Personas
  }
): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, PersonasService.ApiPersonasIdPutPath, 'put');
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
   * To access the full response (for headers, for example), `apiPersonasIdPut$Response()` instead.
   *
   * This method sends `application/*+json` and handles request body of type `application/*+json`.
   */
  apiPersonasIdPut(params: {
    id: number;
    context?: HttpContext
    body?: Personas
  }
): Observable<void> {

    return this.apiPersonasIdPut$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

  /**
   * Path part for operation apiPersonasIdDelete
   */
  static readonly ApiPersonasIdDeletePath = '/api/personas/{id}';

  /**
   * This method provides access to the full `HttpResponse`, allowing access to response headers.
   * To access only the response body, use `apiPersonasIdDelete()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPersonasIdDelete$Response(params: {
    id: number;
    context?: HttpContext
  }
): Observable<StrictHttpResponse<void>> {

    const rb = new RequestBuilder(this.rootUrl, PersonasService.ApiPersonasIdDeletePath, 'delete');
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
   * To access the full response (for headers, for example), `apiPersonasIdDelete$Response()` instead.
   *
   * This method doesn't expect any request body.
   */
  apiPersonasIdDelete(params: {
    id: number;
    context?: HttpContext
  }
): Observable<void> {

    return this.apiPersonasIdDelete$Response(params).pipe(
      map((r: StrictHttpResponse<void>) => r.body as void)
    );
  }

}
