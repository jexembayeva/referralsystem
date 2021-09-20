import { callUpdate } from './actions';
import { INetworkState, defaultState } from '.';

export function networkReducer(state: INetworkState = defaultState, action?: ReturnType<typeof callUpdate>): INetworkState {
    if (action?.type === 'Network.Update') {
        return {
            ...state,
            ...action.payload,
        };
    }

    return state;
}
