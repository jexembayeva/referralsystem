import * as references from './references/actions';
import * as settings from './settings/actions';

type callback = () => void;

const callbacksMap = new Map<any, callback | callback[]>();
//callbacksMap.set(settings.load, references.load);

export default function execute(action: any, dispatch: any) {
    const callback = callbacksMap.get(action);
    if (!callback) {
        return;
    }

    if (Array.isArray(callback)) {
        for (let cb of callback) {
            dispatch(cb());
        }
    }
    else {
        dispatch(callback());
    }
}
