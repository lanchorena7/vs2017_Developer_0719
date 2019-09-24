﻿const Servicios =
{
    ConsultarClientes: () => {
        return axios.get('/api/Personas/Clientes').then(x => x.data)
    },
    ConsultarVendedores: () => {
        return axios.get('/api/Personas/Vendedores').then(x => x.data)
    },
    ConsultarCategorias: () => {
        return axios.get('/api/productos/categorias').then(x => x.data)
    },
    ConsultarProductosPorCategoria: (id) => {
        return axios.get('/api/productos/porCategoria/' + id).then(x => x.data)
    },
    RegistrarVenta: (venta) => {
        return axios.post('/api/Ventas/Registrar', venta).then(x => x.data)
    }
}