import { redirect } from '@sveltejs/kit';

export function load() {
	throw redirect(307, 'https://login.datasektionen.se/login?callback=https://tv.betasektionen.se/login/');
}