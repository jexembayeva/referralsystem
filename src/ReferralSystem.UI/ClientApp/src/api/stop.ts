import { apiClient } from '.';

export type Stop = {
    readonly id: number;
}

export async function list(serviceUri: string) {
    const response = await apiClient.get<Stop[] | undefined>('list', {
        baseURL: serviceUri
    });

    return response.data;
}
