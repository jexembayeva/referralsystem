import * as settings from '../../api/settings';

export interface ISettingsState {
    readonly value?: settings.Settings;
}

export const defaultState: ISettingsState = {
    value: undefined,
}
