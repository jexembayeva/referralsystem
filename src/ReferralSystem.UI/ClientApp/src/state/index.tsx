import { createContext, useContext } from "react";
import { RouteStore } from "./route/store";
import { VehicleStore } from "./vehicle/store";

export class RootStore {
    routeStore: RouteStore;
    vehicleStore: VehicleStore;

    constructor() {
        this.routeStore = new RouteStore();
        this.vehicleStore = new VehicleStore(this);
    }
}

export const rootStores = new RootStore();

export const StoreProvider = createContext(rootStores).Provider;

export const useStores = () => useContext(createContext(rootStores));