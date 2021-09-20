import * as route from '../../api/route';
import * as stop from '../../api/stop';

export interface IReferencesState {

    readonly routes?: Map<number, route.Route>;
    readonly stops?: Map<number, stop.Stop>;
}

export const defaultState: IReferencesState = {
    routes: undefined,
    stops: undefined,
}
