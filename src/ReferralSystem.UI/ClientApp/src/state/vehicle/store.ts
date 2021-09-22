import { makeAutoObservable } from "mobx";
import { IVehicle } from ".";
import { RootStore } from '../';

export class VehicleStore {
    private rootStore?: RootStore;

    public vehicles: IVehicle[] = [
        { id: 1, plate: "as11", ready: true },
        { id: 2, plate: "krg23", ready: false },
        { id: 3, plate: "alm2s", ready: false }
    ];

    constructor(rootStore?: RootStore) {
        this.rootStore = rootStore;
        makeAutoObservable(this)
    };

    public addVehicle = (vehicle: IVehicle) => {
        this.vehicles.push(vehicle);
    };
};