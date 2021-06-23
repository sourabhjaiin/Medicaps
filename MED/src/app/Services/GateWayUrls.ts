export class GatewayUrls{
    readonly LoginEndpoint: string = 'http://localhost:59186/api/auth/login';
    readonly User_Endpoint: string = 'http://localhost:59186/api/auth';
    readonly RegisterEndpoint: string = 'http://localhost:59186/api/auth/register';
    readonly MedEndPoint:string= "http://localhost:59186/api/Medicine";
    readonly AddMed:string= "http://localhost:59186/api/medicine/add";
    readonly MedsearchbyName: string ="http://localhost:59186/api/medicine/searchmed";
    readonly MedsearchbyComp: string="http://localhost:59186/api/medicine/searchcom";
    readonly PharmsearchbyPincode: string ="http://localhost:59186/api/pharmacy/searchpin";
    readonly PharEndPoint: string="http://localhost:59186/api/Pharmacy";
    readonly MedUpdate:string="http://localhost:59186/api/medicine/update";
}