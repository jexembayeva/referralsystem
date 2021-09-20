import { apiClient } from '.';

export type Route = {
    readonly id: number;
}

export async function list(serviceUri: string, routes?: number[] | number) {
    const response = await apiClient.get<Route[] | undefined>('getAll', {
        baseURL: serviceUri,
        params: {
            routes: routes,
        }
    });

    return response.data;
}
