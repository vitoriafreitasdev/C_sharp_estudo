
export default async function UserFetch(data, url) {
    try {
        const request = await fetch(url, {
            method: "post",
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

