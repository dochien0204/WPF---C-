   M S B A M L   `   `   `  ?????  ;Bai1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Bai1Bai1  5   	       Bai1.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   $localclr-namespace:Bai1     5   	   -   5          ? Title$  
MainWindow??5   	   $	??650??6   $	??900??6)   .??5	      ? .+?5
   
   ?? $??Mã sản phẩm:??6   $
??Left=?6'   $??	46,35,0,0q?6B   $	??Top=?6U    J? RenderTransformOrigin$ 0.553,0.387&?6m   $	??183??6?   $??Times New Roman)?6?   $??20(?6?   ?? 5   
   $??Tên sản phẩm :??6   $
??Left=?6)   $??	46,90,0,0q?6D   $	??Top=?6W   $	??183??6o   $??Times New Roman)?6{   $??20(?6?   ?? 5   
   $??Loại sản phẩm:??6   $
??Left=?6)   $??
46,145,0,0q?6D   $	??Top=?6X   $	??183??6p   $??Times New Roman)?6|   $??20(?6?   ?? 5   
   $??Đơn giá:??6   $
??Left=?6#   $??
46,199,0,0q?6>   $	??Top=?6R   $	??183??6j   $??Times New Roman)?6v   $??20(?6?   ?? 5   
   $??Số lượng:??6   $
??Left=?6$   $??
46,251,0,0q?6?   $	??Top=?6S   $ 0.553,-0.653&?6k   $	??183??6?   $??Times New Roman)?6?   $??20(?6?   ?? 5   
   -   5        $??cb_lsp??5      $
??Left=?6!   $??257,146,0,0q?6<   $	??Top=?6Q   $	??307??6i   $??33??6u   $??Times New Roman)?6?   $??20(?6?   5      ?? 5   
   -   5        $??tb_maSp??5      $
??Left=?6"   $??33??6=   $??
257,35,0,0q?6I    ?? TextWrapping$
 Wrap=?6]   $?? ??6q   $	??Top=?6y   $	??307??6?   $??Times New Roman)?6?   $??20(?6?   ?? 5   
   -   5        $??tb_tenSp??5      $
??Left=?6"   $??33??6=   $??
257,90,0,0q?6I   $
 Wrap=?6]   $?? ??6q   $	??Top=?6y   $	??307??6?   $??Times New Roman)?6?   $??20(?6?   ?? 5   
   -   5        $??
tb_soLuong??5      $
??Left=?6$   $??33??6?   $??257,251,0,0q?6K   $
 Wrap=?6`   $?? ??6t   $	??Top=?6|   $	??307??6?   $??Times New Roman)?6?   $??20(?6?   ?? 5   
   -   5        $??	tb_donGia??5      $
??Left=?6#   $??33??6>   $??257,199,0,0q?6J   $
 Wrap=?6_   $?? ??6s   $	??Top=?6{   $	??307??6?   $??Times New Roman)?6?   $??20(?6?   &   System.Windows.Controls.DataGrid  5   
   -   5        $??dg_list??5   /      AutoGenerateColumns$ False??6   $
??Left=?6>   $	??175??6Y   $??110,317,0,0q?6f   $	??Top=?6{   $	??636??6?   $??Times New Roman)?6?   $??20(?6?      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Mã sản phẩm??6>   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   ?? *Masp+6U     5      $ Tên sản phẩm??6?    6%   ?? *Tensp+6W     5      $ 
Mã loại??6@    6%   ?? *Maloai+6S     5      $ Số lượng??6A    6%   ?? *	Soluong+6U     5      $ 
Đơn giá??6@    6%   ?? *Dongia+6S     5      $ Thành Tiền??6C    6%   ?? *	thanhTien+6Y   5      ?? 5   
   -   5        $??Thêm??5      $
??Left=?6!   $??39??6<   $??
10,535,0,0q?6H   $	??Top=?6\   $	??147??6t   $??Times New Roman)?6?   $??20(?6?   5!      ?? 5"   
   -	   5        $??Sửa??5"      $
??Left=?6   $??39??6:   $??183,535,0,0q?6F   $	??Top=?6[   $	??146??6s   $??Times New Roman)?6   $??20(?6?   6?   ?? 5#   
   -
   5        $
??Xóa??5#      $
??Left=?6   $??39??6:   $??354,535,0,0q?6F   $	??Top=?6[   $	??147??6s   $??Times New Roman)?6   $??20(?6?   6?   ?? 5$   
   -   5        $
??Tìm??5$      $
??Left=?6   $??39??6:   $	??Top=?6F   $	??147??6^   $??524,535,0,0q?6j   $??Times New Roman)?6   $??20(?6?   6?   ?? 5%   
   -   5        $??Thống kê??5%      $
??Left=?6$   $??39??6?   $	??Top=?6K   $	??147??6c   $??Times New Roman)?6o   $??20(?6?   $??708,535,0,0q?6?   6?   5'      5(      