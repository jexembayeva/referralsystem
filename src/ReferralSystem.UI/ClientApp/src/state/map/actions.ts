import { IMapState } from '.';

export function callUpdate(payload: IMapState) {
    return {
        type: 'Map.Update',
        payload: payload,
    } as const;
}
