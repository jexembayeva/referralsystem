import { apiClient } from '.';
import { CancelToken } from 'axios';

export type Settings = {
    readonly routeServiceUri: string;
    readonly stopServiceUri: string;
}

export async function get(cancelToken?: CancelToken) {
    console.log("dfd");
    const response = await apiClient.get<Settings>('/settings', {
        cancelToken: cancelToken,
    });

    return response.data;
}
