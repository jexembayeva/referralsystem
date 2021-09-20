export function callUpdate(isLoading: boolean, error?: any) {
    return {
        type: 'Network.Update',
        payload: {
            isLoading: isLoading,
            error: error,
        },
    } as const;
}

export function setLoading(isLoading: boolean) {
    return function (dispatch: any) {
        dispatch(callUpdate(isLoading));
    }
}

export function setError(error: any) {
    return function (dispatch: any) {
        dispatch(callUpdate(false, error));
    }
}
