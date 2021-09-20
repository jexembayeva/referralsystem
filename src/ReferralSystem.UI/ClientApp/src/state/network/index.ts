export interface INetworkState {
    readonly isLoading: boolean;
    readonly error?: any;
}

export const defaultState: INetworkState = {
    isLoading: false,
    error: undefined,
}
