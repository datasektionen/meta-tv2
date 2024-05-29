export async function load({params }) {
    const res = await fetch('https://api.tv.betasektionen.se/JwtToken/IssueNewToken/'+  params.token, {
        method: 'POST'
    });

    const body = await res.json();
    return {
        props: {
            body: body
        }
        
    };
}