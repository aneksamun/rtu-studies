<?php /* Smarty version Smarty-3.0.7, created on 2011-05-19 00:52:04
         compiled from "../templates\content_booker_order.tpl" */ ?>
<?php /*%%SmartyHeaderCode:102644dd43f84d04512-85808558%%*/if(!defined('SMARTY_DIR')) exit('no direct access allowed');
$_smarty_tpl->decodeProperties(array (
  'file_dependency' => 
  array (
    '6a0699a5ca88abb9113267bb2720264fcecc4b4f' => 
    array (
      0 => '../templates\\content_booker_order.tpl',
      1 => 1305755516,
      2 => 'file',
    ),
  ),
  'nocache_hash' => '102644dd43f84d04512-85808558',
  'function' => 
  array (
  ),
  'has_nocache_code' => false,
)); /*/%%SmartyHeaderCode%%*/?>
<form name="booker_order" action="<?php echo $_smarty_tpl->getVariable('formaction')->value;?>
" method="POST">
<input type="hidden" name="page" id="page" value="<?php echo $_smarty_tpl->getVariable('nextpage')->value;?>
" />
	<div class="post">
		<h1 class="title">
			<a>Apstiprināto tēmu saraksts</a>
		</h1>
		<br/>
		<?php if (count($_smarty_tpl->getVariable('approvedTitles')->value)==0){?>
			<div class="text">
				<span>Neviens ieraksts nav atrasts. </span>
				<a href="javascript:location.reload(true)">Atjaunot datus.</a>
			</div>
		<?php }else{ ?>
			<div class="right">
				<table width="100%" cellspacing="0" cellpadding="0">
					<tr class="head">
						<td>Tēmas nosaukums</td>
						<td>Tēmas nosaukums svešvalodā</td>
						<td>Vadītājs</td>
						<td>Students</td>
						<td align="center">Izvēlēties</td>
					</tr>
					<?php  $_smarty_tpl->tpl_vars['title'] = new Smarty_Variable;
 $_from = $_smarty_tpl->getVariable('approvedTitles')->value; if (!is_array($_from) && !is_object($_from)) { settype($_from, 'array');}
if ($_smarty_tpl->_count($_from) > 0){
    foreach ($_from as $_smarty_tpl->tpl_vars['title']->key => $_smarty_tpl->tpl_vars['title']->value){
?>
						<tr>
							<td><?php echo $_smarty_tpl->tpl_vars['title']->value['native_title'];?>
</td>
							<td><?php echo $_smarty_tpl->tpl_vars['title']->value['broad_title'];?>
</td>
							<td><?php echo $_smarty_tpl->tpl_vars['title']->value['lecturer'];?>
</td>
							<td><?php echo $_smarty_tpl->tpl_vars['title']->value['student'];?>
</td>
							<td align="center">
								<input type="checkbox" />
							</td>
						</tr>
					<?php }} ?>
				</table>
				<div class="order_action">
					<button name="order" type="submit" onclick="javascript:alert('Funkcija taps izstrādes 2. stadijā'); return false;">Veidot rīkojumus</button>&nbsp;
					<button name="task" type="submit" onclick="javascript:alert('Funkcija taps izstrādes 2. stadijā'); return false;">Sastadīt uzdevumus</button>
				</div>
			</div>
		<?php }?>
	</div>
</form>