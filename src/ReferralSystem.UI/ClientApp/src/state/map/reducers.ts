import { callUpdate } from './actions';
import { IMapState, defaultState } from '.';

export function mapReducer(state: IMapState = defaultState, action?: ReturnType<typeof callUpdate>): IMapState {
    if (action?.type === 'Map.Update') {
        return {
            ...state,
            ...action.payload,
        };
    }

    return state;
}
