    <div class="menu">
      <ul>
      	{foreach from=$menu item=i_menu}
          <li {if $i_menu->selected}class="current"{/if}><a href="?page={$i_menu->page}">{$i_menu->title}</a></li>
        {/foreach}
      </ul>
    </div>