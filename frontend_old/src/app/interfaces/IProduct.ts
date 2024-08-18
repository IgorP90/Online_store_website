export interface IProduct{
    id?:number,
    name:string,
    description:string
    price:number 
    image:string
    numberOfOrders:number
    rating:number
    dateTime?: Date
}