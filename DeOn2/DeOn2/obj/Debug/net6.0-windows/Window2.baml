   M S B A M L   `   `   `  ????@  <DeOn2, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:DeOn2DeOn2  5   	       DeOn2.Window2   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:DeOn2     5   	   -   5          ? Title$  Window2??5   	   $	??450??6   $	??800??6&   .??5	      ? .+?5
   
   &   System.Windows.Controls.DataGrid  -   5        $??dg_list??5
         AutoGenerateColumns$ False??6"   $??Center=?6>   $	??165??6[   $	??Top=?6h   $	??640??6?   $??Times New Roman)?6?   $??20(?6?   $??0,27,0,0q?6?      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã sản phẩm??6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6:   ?? *MaSp+   HeaderStyle 5      ?? 5       ?? 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6    .?5      ??  ?? Property ? ?? ?? Value$ Center=?6D   ?? 5       ? ??$
 Bold"?6;   ?? 5       ? ??
 ?????6<   5      	   ElementStyle	 5      ?? 5      " ??6    .?5      ??  ? ??$ Center=?6D   5      5        5      $ Tên sản phẩm??6%    6;   ?? *
TenSanPham+ 5      ?? 5      "  6    .?5      ??  ? ??$ Center=?6D   ?? 5       ? ??$
 Bold"?6;   ?? 5       ? ??
 ?????6<   5       	 5"      ?? 5#      " ??6    .?5$      ??  ? ??$ Center=?6D   5%      5'        5(      $ 
Đơn giá??6%    66   ?? *DonGia+ 5)      ?? 5*      "  6    .?5+      ??  ? ??$ Center=?6D   ?? 5,       ? ??$
 Bold"?6;   ?? 5-       ? ??
 ?????6<   5.      	 50      ?? 51      " ??6    .?52      ??  ? ??$ Center=?6D   53      55        56      $ Số lượng bán??6%    6;   ?? *
SoLuongBan+ 57      ?? 58      "  6    .?59      ??  ? ??$ Center=?6D   ?? 5:       ? ??$
 Bold"?6;   ?? 5;       ? ??
 ?????6<   5<      	 5>      ?? 5?      " ??6    .?5@      ??  ? ??$ Center=?6D   5A      5C        5D      $ Nhóm hàng??6%    68   ?? *TenNhomHang+ 5E      ?? 5F      "  6    .?5G      ??  ? ??$ Center=?6D   ?? 5H       ? ??$
 Bold"?6;   ?? 5I       ? ??
 ?????6<   5J      	 5L      ?? 5M      " ??6    .?5N      ??  ? ??$ Center=?6D   5O      5Q        5R      $ Tiền bán??6%    67   ?? *	TienBan+ 5S      ?? 5T      "  6    .?5U      ??  ? ??$ Center=?6D   ?? 5V       ? ??$
 Bold"?6;   ?? 5W       ? ??
 ?????6<   5X      	 5Z      ?? 5[      " ??6    .?5\      ??  ? ??$ Center=?6D   ?? 5]       ? ??$
 Bold"?6;   5^      5`      5b      5c      5d      