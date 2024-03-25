<script>
    import Group from "$lib/Group.svelte";
    import { State } from "$lib/index.js";
</script>

<button>Create Slide Collection</button>
<Group state={State.create} priority={true}/>

<h1>Currently in META</h1>
<Group state={State.preview} lastEditedBy="stensvad" priority={true} neverExpire={true}/>

<h1>Upcoming</h1>
<Group state={State.preview} hidden={true} lastEditedBy="stensvad"/>

<style>
    h1 {
        text-decoration: underline;
        font-size: 2.5rem;
        margin: 0;
    }
</style>