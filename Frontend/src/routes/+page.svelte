<script>
    import Group from '../lib/Group.svelte'
</script>
<button>Create Slide Collection</button>
<h1 class="main_page_header">Currently in META</h1>
<Group priority = {true} state = "create"/>

<h1 class="main_page_header">Upcoming</h1>

<Group lastEditedBy = "stensvad" priority = {true} neverExpire = {true}/>
<Group hidden = {true} lastEditedBy = "stensvad"/>

<style>
    .main_page_header{
        text-align: center;
        text-decoration: underline;
        font-size: 3em;
    }
</style>