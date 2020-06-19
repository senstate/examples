<script>
	import {createWatchSender, createLogSender} from '@senstate/client';

	const watcher = createWatchSender({tag: 'my counter'});
	const logger = createLogSender(1 /* Info */, 'some logger name');

	export let name;
		
	let count = 0;

	function handleClick() {
	  count += 1;
	  watcher(count);
	  logger('clicked');
	}
</script>

<main>
	<h1>Hello {name}!</h1>


	<button on:click={handleClick}>
		Clicked {count} {count === 1 ? 'time' : 'times'}
	</button>

</main>

<style>
	main {
		text-align: center;
		padding: 1em;
		max-width: 240px;
		margin: 0 auto;
	}

	h1 {
		color: #ff3e00;
		text-transform: uppercase;
		font-size: 4em;
		font-weight: 100;
	}

	@media (min-width: 640px) {
		main {
			max-width: none;
		}
	}
</style>