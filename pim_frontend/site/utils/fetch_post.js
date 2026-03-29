
export default async function UserFetch(data, url, method = "post") {
    try {
        const request = await fetch(url, {
            method: method,
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(data)
        });
            
        const res = await request.json()
        
        return res
    } catch (error) {
        return error
    }
} 

