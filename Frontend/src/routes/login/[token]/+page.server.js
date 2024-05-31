/** @type {import('./$types').PageLoad} */
export async function load({ fetch, params }) {	
    const res = await fetch('https://api.tv.betasektionen.se/JwtToken/IssueNewToken/${params.token}', {
        method: 'POST'
    });	
    const item = await res.json();
return { item };}