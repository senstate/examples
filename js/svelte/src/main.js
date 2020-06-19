import App from './App.svelte';
import {setSenstateConnection} from "@senstate/client-connection";

setSenstateConnection({
	name: 'My Svelte Example',
});

const app = new App({
	target: document.body,
	props: {
		name: 'svelte'
	}
}); 

export default app;