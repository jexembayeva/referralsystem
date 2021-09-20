import { combineReducers } from 'redux';
import { connectRouter, RouterState } from 'connected-react-router';
import { History } from 'history';

import { INetworkState } from './network';
import { networkReducer } from './network/reducers';

import { IReferencesState } from './references';
import { referencesReducer } from './references/reducers';

import { ISettingsState } from './settings';
import { settingsReducer } from './settings/reducers';

export interface IAppState {
    readonly network: INetworkState;
    readonly references: IReferencesState;
    readonly settings: ISettingsState;

    readonly router: RouterState<any>;
}

export const rootReducer = (history: History<any>) => combineReducers<IAppState>({
    network: networkReducer,
    references: referencesReducer,
    settings: settingsReducer,

    router: connectRouter(history),
});
