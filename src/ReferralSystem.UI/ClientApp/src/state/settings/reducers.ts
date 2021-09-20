import { callUpdate } from './actions';
import { ISettingsState, defaultState } from '.';

export function settingsReducer(state: ISettingsState = defaultState, action: ReturnType<typeof callUpdate>): ISettingsState {
    if (action.type === 'Settings.Update') {
        return {
            ...state,
            ...action.payload,
        };
    }

    return state;
}
