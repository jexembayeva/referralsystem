import { makeAutoObservable } from "mobx";
import { IRoute } from ".";

export class RouteStore {
    public routes: IRoute[] = [
        { id: 1, point: 10, completed: true },
        { id: 2, point: 12, completed: false },
        { id: 3, point: 32, completed: false }
    ];

    constructor() {
        makeAutoObservable(this)
    }

    public addRoute = (route: IRoute) => {
        this.routes.push(route);
    };
};