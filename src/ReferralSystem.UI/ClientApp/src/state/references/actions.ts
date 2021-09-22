import {IReferencesState} from '.';
import {setLoading, setError} from '../network/actions';
import executeCallbacks from '../callbacks';
import * as route from '../../api/route';
import * as stop from '../../api/stop';

export function callUpdate(payload: IReferencesState) {
    return {
        type: 'References.Update',
        payload: payload,
    } as const;
}

//export function load() {
//    return async function (dispatch: any, getState: () => IAppState) {
//        const settings = await getState().settings.value;
//        if (!settings) {
//            return;
//        }
//        dispatch(setLoading(true));

//        Promise.all([route.list(settings.routeServiceUri), stop.list(settings.stopServiceUri)])
//            .then(([routes, stops]) => {
//                dispatch(callUpdate({
//                    routes: toMap(routes, r => r.id),
//                    stops: toMap(stops, s => s.id)
//                }));

//                executeCallbacks(load, dispatch);
//                console.log(routes);
//            })
//            .catch(error => dispatch(setError(error)))
//            .finally(() => dispatch(setLoading(false)));
//    };
//}

function toMap<K, V>(values: V[] | undefined, keySelector: (value: V) => K) {
    if (!values) {
        return undefined;
    }

    const map = new Map<K, V>();
    values.forEach(value => map.set(keySelector(value), value));

    return map;
}
