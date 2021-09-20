import { callUpdate } from './actions';
import { IReferencesState, defaultState } from '.';

export function referencesReducer(state: IReferencesState = defaultState, action?: ReturnType<typeof callUpdate>): IReferencesState {
    if (action?.type === 'References.Update') {
        return {
            ...state,
            ...action.payload,
        };
    }

    return state;
}
