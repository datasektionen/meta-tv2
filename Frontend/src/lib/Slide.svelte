<script>
    import Post from "./Post.svelte";

    export let posts = [1, 2, 3];
    export let numScreens = 3;
</script>

<div class="slide-container">
    {#each posts as post}
        <Post />
    {/each}
</div>

<style>
    .slide-container {
        background-color: white;
        width: 90%;
        border-radius: 15px;
        display: flex;
        justify-content: space-evenly;
        align-items: center;
        padding: 20px;
        margin: auto;
    }
</style>