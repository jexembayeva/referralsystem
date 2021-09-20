
export interface IMapState {
    readonly routeId?: number;
    readonly directionIndex: number;
    readonly isLandscape: boolean;
}

export const defaultState: IMapState = {
    routeId: undefined,
    directionIndex: 0,
    isLandscape: false,
}
