// src/hooks/useApi.js

import { useState } from 'react';
import axios from 'axios'; // Ensure axios is installed

const useApi = (url, method = 'POST') => {
    const [data, setData] = useState(null);
    const [isLoading, setIsLoading] = useState(false);
    const [error, setError] = useState(null);

    const callApi = async (requestData) => {
        setIsLoading(true);
        setError(null);
        try {
            const response = await axios({
                method,
                url,
                data: requestData,
            });
            setData(response.data); // Set the API response data
        } catch (err) {
            setError(err); // Set error if the request fails
        } finally {
            setIsLoading(false); // Reset loading state when done
        }
    };

    return { data, isLoading, error, callApi };
};

export default useApi;
