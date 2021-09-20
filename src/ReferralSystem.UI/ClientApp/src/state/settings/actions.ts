import { setLoading, setError } from '../network/actions';
import executeCallbacks from '../callbacks';
import * as settings from '../../api/settings';

export function callUpdate(value?: settings.Settings) {
    return {
        type: 'Settings.Update',
        payload: {
            value: value,
        },
    } as const;
}

export function load() {
    console.log('gdg');
    return function (dispatch: any) {
        dispatch(setLoading(true));

        settings.get()
            .then(async s => {
                await dispatch(callUpdate(s));

                executeCallbacks(load, dispatch);
            })
            .catch(error => dispatch(setError(error)))
            .finally(() => dispatch(setLoading(false)));
    };
}
