import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Headers, RequestOptions } from '@angular/http';

@Component({
    selector: 'game',
    templateUrl: './game.component.html',
    styleUrls: ['./game.component.css']
})
export class GameComponent {
    public fields: Field[][];
    public _baseUrl: string;
    //private _http: Http;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        //_http = http;
        http.get(baseUrl + 'api/Game/GetFields').subscribe(result => {
            this._baseUrl = baseUrl;
            var totalField = result.json() as GameData;
            this.fields = totalField.fields;

            //this.fields = [];
            //for (var i: number = 0; i < totalField.width; i++) {
            //    this.fields[i] = [];
            //    for (var j: number = 0; j < totalField.height; j++) {
            //        var fd = totalField.fields[i * totalField.height + j];
            //        var f = new Field();
            //        f.number = fd.number;
            //        f.open = fd.open;
            //        this.fields[i][j] = f;
            //    }
            //}

        }, error => console.error(error));
    }

    public open(field: Field, x:number, y:number) {
        console.log(this._baseUrl);
        console.log(field.number + ' ' + x+ ' '+y);
        let uInput = JSON.stringify({x:x,y:y});
        let headers = new Headers({ 'Content-Type': 'application/json' });
        let options = new RequestOptions({ headers: headers });
        this.http.post(this._baseUrl + 'api/Game/OpenField', uInput, options).subscribe(result => {
            console.log(123);
            var totalField = result.json() as GameData;
            this.fields = totalField.fields;
        }, error => console.error(error));
    }
}


interface GameData {
    fields: Field[][];
    width: number;
    height: number;
}
class Field {
    number: string;
    open: boolean;
}
