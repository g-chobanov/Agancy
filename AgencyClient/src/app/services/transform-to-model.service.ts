import { Injectable } from '@angular/core';

export abstract class TransformToModelService<T> {

    abstract transformFromForm(form: any) : T;

    abstract transformFromJson(json: any) : T;
}
