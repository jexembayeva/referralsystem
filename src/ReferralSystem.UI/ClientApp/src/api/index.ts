import axios from 'axios';
import qs from 'qs';

export const apiClient = axios.create({
    paramsSerializer: (params) => {
        return qs.stringify(params, { arrayFormat: 'repeat' })
    },
});

apiClient.interceptors.response.use(response => {
    if (response.status === 204) {
        response.data = undefined;
    }

    if (response.data === '') {
        response.data = undefined;
    }

    return response;
});
