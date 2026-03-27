
export default async function get_func(url) {
    try {
        const res = await fetch(url)
        return await res.json()

    } catch (error) {
        return error
    }
}